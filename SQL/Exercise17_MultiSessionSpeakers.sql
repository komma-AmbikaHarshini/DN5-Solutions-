-- Exercise 17: Multi-Session Speakers
-- Identify speakers who are handling more than one session across all events.

SELECT 
    speaker_name,
    COUNT(session_id) AS total_sessions_handled,
    COUNT(DISTINCT event_id) AS distinct_events_count
FROM Sessions
GROUP BY speaker_name
HAVING COUNT(session_id) > 1
ORDER BY total_sessions_handled DESC;
