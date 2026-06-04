-- Exercise 21: Top Feedback Providers
-- List top 5 users who have submitted the most feedback entries.

SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.email AS user_email,
    COUNT(f.feedback_id) AS total_feedback_submitted
FROM Users u
JOIN Feedback f ON u.user_id = f.user_id
GROUP BY u.user_id, u.full_name, u.email
ORDER BY total_feedback_submitted DESC
LIMIT 5;
