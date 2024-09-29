using Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Drive;
using Kitchen.Application.UnitOfWork;
using Kitchen.Infrastructure.Enum;
using Kitchen.Infrastructure.Services.IServices;
using MediatR;

namespace Kitchen.Application.Handler.Firebase;

public class UploadFileHandler : IRequestHandler<UploadFileRequest, Unit>
{
    private readonly IUnitOfWork _unit;
    private IFirebaseService _firebase;
    public UploadFileHandler(IFirebaseService firebase, IUnitOfWork unit)
    {
        _firebase = firebase;
        _unit = unit;
    }


    public async Task<Unit> Handle(UploadFileRequest request, CancellationToken cancellationToken)
    {
        string fileName = request.UploadType + "-" + request.Id;
        var fileUrl = await _firebase.UploadImage(request.File, fileName);

        switch (request.UploadType)
        {
            case UploadType.Avarta:
                var user = await _unit.UserRepository.GetByIdAsync(request.Id) ??
                           throw new NotFoundException("UserId not found");
                user.Avarta = fileUrl;
                _unit.UserRepository.Update(user);
                break;
            case UploadType.Recipe:
                var recipe = await _unit.RecipeRepository.GetByIdAsync(request.Id) ??
                             throw new NotFoundException("RecipeId not found");
                recipe.ImageUrl = fileUrl;
                _unit.RecipeRepository.Update(recipe);
                break;
            case UploadType.Post:
                var post = await _unit.PostRepository.GetByIdAsync(request.Id) ??
                           throw new NotFoundException("PostId not found");
                post.ImageUrl = fileUrl;
                _unit.PostRepository.Update(post);
                break;
        }

        if (await _unit.SaveChangeAsync() < 0) throw new NotImplementException("Update file to DB failed");

        return Unit.Value;
    }
}