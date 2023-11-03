using AutoMapper;
using FluentValidation;
using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Contracts.Infrastrcture.PhotoService;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Dtos.Episode.Validators;
using Herokume.Application.Dtos.Series;
using Herokume.Application.Dtos.Series.Validator;
using Herokume.Application.Features.Commands.Series.Requests;
using Herokume.Application.Models.Mail;
using MediatR;

namespace Herokume.Application.Features.Commands.Series.Handlers;

public class CreateSeriesHandler : IRequestHandler<CreateSeries, Unit>
{
    private readonly ISeriesRepository _seriesRepository;
    private readonly IMapper _mapper;
    private readonly IPhotoService _photoService;

    private IEmailService _emailService { get; }

    public CreateSeriesHandler(
        ISeriesRepository seriesRepository,
        IMapper mapper,
        IEmailService emailService,
        IPhotoService photoService)
    {
        _seriesRepository = seriesRepository;
        _mapper = mapper;
        _emailService = emailService;
        _photoService = photoService;
    }



    public async Task<Unit> Handle(CreateSeries request, CancellationToken cancellationToken)
    {
        var validator = new CreateSeriesDtoValidator();
        var validatorResult = await validator.ValidateAsync(request.CreateSeriesDto, cancellationToken);
        if (!validatorResult.IsValid)
            throw new Exception();


        //upload photo
        var result = await _photoService.AddImage(request.CreateSeriesDto.ImageFile);


        var series = _mapper.Map<Domain.Entities.Series>(request.CreateSeriesDto);
        series.Image = result?.Uri.ToString();


        await _seriesRepository.Add(series);


        //TODO: Get email of User
        var email = new Email
        {
            To = "UserAccount@gmail.com",
            Body = "Your Series has been submitted successfully",
            Subject = "Series has submitted"
        };


        //Sending email
        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            //log it 
        }




        return Unit.Value;
    }
}
