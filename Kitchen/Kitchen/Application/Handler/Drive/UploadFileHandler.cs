using Application.ErrorHandlers;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Drive;
using Kitchen.Application.UnitOfWork;
using Kitchen.Infrastructure.Enum;
using Kitchen.Infrastructure.Services.IServices;
using MediatR;

namespace Kitchen.Application.Handler.Drive;

public class UploadFileHandler : IRequestHandler<UploadFileRequestDto, Unit>
{
    private readonly IUnitOfWork _unit;
    private IDriveService _drive;

    public UploadFileHandler(IUnitOfWork unit, IDriveService drive)
    {
        _unit = unit;
        _drive = drive;
    }

    public async Task<Unit> Handle(UploadFileRequestDto request, CancellationToken cancellationToken)
    {
        string fileName = request.UploadType + "-" + request.Id + "-" + request.ContentType;
        var fileUrl = await _drive.UploadFileToGoogleDrive(request.File, fileName, request.ContentType);

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