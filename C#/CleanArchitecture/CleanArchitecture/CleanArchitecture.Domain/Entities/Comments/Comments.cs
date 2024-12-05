namespace CleanArchitecture.Domain.Entities.Comments;

using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities.Comments.Events;
using CleanArchitecture.Domain.Entities.Rentals;

public class Comments : Entity
{
    private Comments(Guid id, Guid carId, Guid rentalId, Guid userId, Rating rating, Comment comment, DateTime? createdAt) : base(id)
    {
        CarId = carId;
        RentalId = rentalId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedAt = createdAt;
    }

    public Guid CarId { get; private set; }

    public Guid RentalId { get; private set; }

    public Guid UserId { get; private set; }

    public Rating Rating { get; private set; }

    public Comment Comment { get; private set; }

    public DateTime? CreatedAt { get; private set; }


    public static Result<Comments> Create(Rentals rentals, Rating rating, Comment comment, DateTime createdAt)
    {
        if (rentals.Status != RentalStatus.Completed)
        {

            return Result.Failure<Comments>(CommentsErrors.NotElegible);
        }

        var comments = new Comments
        (
            Guid.NewGuid(),
            rentals.CarId,
            rentals.Id,
            rentals.UserId,
            rating,
            comment,
            createdAt
        );

        comments.RaiseDomainEvent(new CommentCreatedDomainEvents(comments.Id));

        return comments;
    }
}
