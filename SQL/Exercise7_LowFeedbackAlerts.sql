-- Exercise 7: Low Feedback Alerts
-- List all users who gave feedback with a rating less than 3, along with their comments and associated event names.

SELECT 
    u.user_id,
    u.full_name AS user_name,
    f.rating,
    f.comments,
    e.event_id,
    e.title AS event_name
FROM Feedback f
JOIN Users u ON f.user_id = u.user_id
JOIN Events e ON f.event_id = e.event_id
WHERE f.rating < 3;
