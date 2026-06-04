// Task 4: In-memory events store
const events = [
    { id: 1, name: "Symphony Orchestra Night", category: "Music", seats: 30 },
    { id: 2, name: "Web Development Bootcamp", category: "Tech", seats: 15 },
    { id: 3, name: "Modern Painting Workshop", category: "Arts", seats: 10 },
    { id: 4, name: "Acoustic Folk Live", category: "Music", seats: 25 },
    { id: 5, name: "AI & Neural Networks Seminar", category: "Tech", seats: 50 }
];

// Helper to log to on-screen console
function logToFunctionsConsole(message, type = 'info') {
    const consoleBox = document.getElementById('functionsConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Task 4: Closure function to track registrations per category
function createRegistrationTracker(categoryName) {
    let registrationCount = 0; // Outer variable (lexical scope)
    return function() {
        registrationCount++; // Closure updates outer variable
        logToFunctionsConsole(`[Closure] Counter updated for ${categoryName}. Current count: ${registrationCount}`, "success");
        return registrationCount;
    };
}

// Instantiate trackers for each category
const categoryTrackers = {
    Music: createRegistrationTracker("Music"),
    Tech: createRegistrationTracker("Tech"),
    Arts: createRegistrationTracker("Arts")
};

// Task 4: addEvent function
function addEvent(name, category, seats) {
    const id = events.length + 1;
    const newEvent = { id, name, category, seats: parseInt(seats) };
    events.push(newEvent);
    logToFunctionsConsole(`Event added: "${name}" [${category}] with ${seats} seats.`, "success");
    runFilters(); // Refresh display
}

// Task 4: registerUser function
function registerUser(eventId) {
    const event = events.find(e => e.id === eventId);
    if (!event) {
        logToFunctionsConsole(`Error: Event with ID ${eventId} not found.`, "error");
        return;
    }

    if (event.seats <= 0) {
        logToFunctionsConsole(`Error: "${event.name}" has no available seats.`, "error");
        return;
    }

    // Decrement seats
    event.seats--;
    logToFunctionsConsole(`Registered user for "${event.name}". Seats remaining: ${event.seats}`, "info");

    // Call category registration closure
    if (categoryTrackers[event.category]) {
        const count = categoryTrackers[event.category]();
        document.getElementById(`regCount${event.category}`).textContent = count;
    }

    runFilters(); // Refresh UI
}

// Task 4: Higher-Order Function (takes list and callback function)
function filterEvents(list, callback) {
    const results = [];
    list.forEach(item => {
        if (callback(item)) {
            results.push(item);
        }
    });
    return results;
}

// Filter events by category helper
function filterEventsByCategory(list, category) {
    if (category === "All") return list;
    return filterEvents(list, event => event.category === category);
}

// Apply both category and text search filters
function runFilters() {
    const category = document.getElementById('filterCategory').value;
    const query = document.getElementById('searchQuery').value.toLowerCase();
    
    logToFunctionsConsole(`Applying filters: category="${category}", search="${query}"`, "info");
    
    // First, filter by category
    let filtered = filterEventsByCategory(events, category);
    
    // Task 4: Pass callbacks to HOF filterEvents for dynamic query search
    filtered = filterEvents(filtered, event => {
        return event.name.toLowerCase().includes(query);
    });

    renderEvents(filtered);
}

// Render events to UI
function renderEvents(list) {
    const container = document.getElementById('eventsListContainer');
    container.innerHTML = '';
    
    if (list.length === 0) {
        container.innerHTML = '<p style="color: var(--text-secondary); text-align: center;">No events match your criteria.</p>';
        return;
    }

    list.forEach(event => {
        const card = document.createElement('div');
        card.className = 'event-card';
        card.innerHTML = `
            <div class="event-info">
                <h3>${event.name} <span class="event-tag">${event.category}</span></h3>
                <p>Available Seats: ${event.seats}</p>
            </div>
            <div>
                <button class="btn btn-primary" onclick="registerUser(${event.id})" ${event.seats <= 0 ? 'disabled' : ''}>
                    ${event.seats <= 0 ? 'Full' : 'Register'}
                </button>
            </div>
        `;
        container.appendChild(card);
    });
}

// Form Submission handler
function handleAddEvent() {
    const name = document.getElementById('eventNameInput').value.trim();
    const category = document.getElementById('eventCategoryInput').value;
    const seats = document.getElementById('eventSeatsInput').value;

    if (!name) {
        logToFunctionsConsole("Error: Please provide a valid event name.", "error");
        return;
    }
    
    addEvent(name, category, seats);
    
    // Reset name input
    document.getElementById('eventNameInput').value = '';
}

// Initialize
document.addEventListener('DOMContentLoaded', () => {
    logToFunctionsConsole("Trackers initialized for Music, Tech, and Arts.", "info");
    runFilters();
});
