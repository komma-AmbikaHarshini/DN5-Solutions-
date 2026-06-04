-- Exercise 13: Average Rating per City
-- Calculate the average feedback rating of events conducted in each city.

SELECT 
    e.city,
    AVG(f.rating) AS average_feedback_rating,
    COUNT(f.feedback_id) AS total_feedbacks_received
FROM Events e
JOIN Feedback f ON e.event_id = f.event_id
GROUP BY e.city
ORDER BY average_feedback_rating DESC;
