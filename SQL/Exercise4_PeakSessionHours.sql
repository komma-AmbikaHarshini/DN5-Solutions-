-- Exercise 4: Peak Session Hours
-- Count how many sessions are scheduled between 10 AM to 12 PM (inclusive) for each event.

SELECT 
    event_id,
    COUNT(session_id) AS sessions_scheduled_10_to_12
FROM Sessions
WHERE TIME(start_time) >= '10:00:00' 
  AND TIME(end_time) <= '12:00:00'
GROUP BY event_id;
