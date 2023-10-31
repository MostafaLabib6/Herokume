using Herokume.Application.Dtos.Comment;
using MediatR;

namespace Herokume.Application.Features.Queries.Comments.Requests;

public class GetCommentsList : IRequest<List<CommentsListDto>>
{
}
