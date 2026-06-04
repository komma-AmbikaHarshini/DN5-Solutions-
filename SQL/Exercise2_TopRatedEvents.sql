-- Exercise 2: Top Rated Events
-- Identify events with the highest average rating, considering only those that have received at least 10 feedback submissions.

SELECT 
    e.event_id,
    e.title AS event_title,
    AVG(f.rating) AS average_rating,
    COUNT(f.feedback_id) AS feedback_count
FROM Events e
JOIN Feedback f ON e.event_id = f.event_id
GROUP BY e.event_id, e.title
HAVING COUNT(f.feedback_id) >= 10
ORDER BY average_rating DESC;
