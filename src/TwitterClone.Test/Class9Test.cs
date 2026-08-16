using System;
using System.Collections.Generic;
using TwitterClone.Domain.Entities.Notifications;

namespace TwitterClone.Test;

public class Class9Test
{
  public void Run()
  {
    var recipientUserId = Guid.NewGuid();
    var actorUserId = Guid.NewGuid();
    var tweetId = Guid.NewGuid();
    var creatorId = Guid.NewGuid();
    var now = DateTime.UtcNow;

    var notifications = new List<Notification>()
    {
      new LikeNotification(
        id: Guid.NewGuid(),
        userId: recipientUserId,
        content: "User liked your tweet",
        likedBy: actorUserId,
        tweetId: tweetId,
        createdAt: now,
        createdBy: creatorId
      ),
      new CommentNotification(
        id: Guid.NewGuid(),
        userId: recipientUserId,
        content: "User commented on your tweet",
        commentedBy: actorUserId,
        tweetId: tweetId,
        createdAt: now,
        createdBy: creatorId
      ),
      new FollowNotification(
        id: Guid.NewGuid(),
        userId: recipientUserId,
        content: "User followed you",
        followedBy: actorUserId,
        createdAt: now,
        createdBy: creatorId
      ),
      new SystemNotification(
        id: Guid.NewGuid(),
        userId: recipientUserId,
        content: "System update scheduled",
        createdAt: now,
        createdBy: creatorId
      )
    };

    foreach (var notification in notifications)
    {
      Console.WriteLine(notification.DescribeRecord());
    }
  }
}