using Kitchen.Application.Models.Responses.Forum;
using Kitchen.Application.Utils;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Mapper;

public static class PostsMapper
{
    public static List<GetPostsResponse> PostsToListGetPostsResponseDto(List<Post> dto)
    {
        return dto.Select(x => new GetPostsResponse()
        {
            PostId = x.Id,
            Title = x.Title,
            Content = x.Content,
            ImageUrl = x.ImageUrl,
            Category = x.PostCategory!.CategoryName,
            NumberOfComment = x.Comments?.Count
        }).ToList();
    }

    public static GetPostDetailResponse PostToPostDetailResponseDto(Post dto) => new GetPostDetailResponse()
    {
        PostId = dto.Id,
        Author = dto.Poster!.UserName,
        Avarta = dto.Poster!.Avarta,
        Category = dto.PostCategory!.CategoryName,
        PostContent = dto.Content,
        PostDate = DateUtils.FormatDateTimeToDatetimeV1(dto.PostDate),
        PostImageUrl = dto.ImageUrl,
        Title = dto.Title,
        NumberOfComment = dto.Comments!.Count,
        Comments = dto.Comments!.Select(x => new CommentDto()
        {
            Avarta = x.User!.Avarta,
            Commenter = x.User!.UserName,
            CommentContent = x.Content,
            CommentDate = DateUtils.FormatDateTimeToDatetimeV1(x.CommentDate)
        }).ToList()
    };
}