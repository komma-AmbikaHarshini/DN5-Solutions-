-- Exercise 20: User Engagement Index
-- For each user, calculate how many events they registered/attended and how many feedbacks they submitted.

SELECT 
    u.user_id,
    u.full_name AS user_name,
    (SELECT COUNT(DISTINCT event_id) FROM Registrations WHERE user_id = u.user_id) AS events_attended_count,
    (SELECT COUNT(feedback_id) FROM Feedback WHERE user_id = u.user_id) AS feedbacks_submitted_count
FROM Users u;
