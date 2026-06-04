-- Exercise 24: Average Session Duration per Event
-- Compute the average duration (in minutes) of sessions in each event.

SELECT 
    s.event_id,
    e.title AS event_title,
    AVG(TIMESTAMPDIFF(MINUTE, s.start_time, s.end_time)) AS average_session_duration_minutes,
    COUNT(s.session_id) AS total_sessions_measured
FROM Sessions s
JOIN Events e ON s.event_id = e.event_id
GROUP BY s.event_id, e.title;
