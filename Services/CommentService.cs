using AutoMapper;
using DgmBobinajServer.DTOs.Comment;
using DgmBobinajServer.Models;
using DgmBobinajServer.Repositories;
using ED.Result;

namespace DgmBobinajServer.Services;

public sealed class CommentService(
    CommentRepository commentRepository,
    IMapper mapper)
{
    public async Task<Result<string>> Create(CreateCommentDto request, CancellationToken cancellationToken)
    {
        Comment comment = mapper.Map<Comment>(request);
        comment.IsActive = false;
        comment.CreatedDate = DateTime.Now;
        comment.CreatedBy = "Admin";
        return await commentRepository.Create(comment, cancellationToken);
    }

    public async Task<Result<List<Comment>>> GetAll(CancellationToken cancellationToken)
    {
        return await commentRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<Comment>>> GetAllByIsActive(CancellationToken cancellationToken)
    {
        return await commentRepository.GetAllByIsActive(cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateCommentDto request, CancellationToken cancellationToken)
    {
        Comment? comment = commentRepository.GetById(request.Id);
        if (comment is null)
        {
            return Result<string>.Failure("Yorum bulunamadı");
        }

        if(comment.IsUpdateable == false)
        {
            return Result<string>.Failure("Yorum yapılamıyor. Lütfen yetkili kişiye başvurun!");
        }

        mapper.Map(request, comment);
        comment.IsUpdateable = false;
        comment.IsActive = true;
        comment.UpdatedDate = DateTime.Now;
        comment.UpdatedBy = request.CommentName;
        return await commentRepository.Update(comment, cancellationToken);
    }

    public async Task<Result<string>> DeleteById(Guid Id, CancellationToken cancellationToken)
    {
        return await commentRepository.DeleteById(Id, cancellationToken);
    }
}
