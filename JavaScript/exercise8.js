const interactiveEvents = [
    { id: 201, name: "Public Speaking Seminar", category: "Education", seats: 12 },
    { id: 202, name: "Wilderness Hiking Club", category: "Recreation", seats: 8 },
    { id: 203, name: "Food Drive Volunteering", category: "Charity", seats: 20 },
    { id: 204, name: "Intro to Python for Kids", category: "Education", seats: 5 },
    { id: 205, name: "Biking Tour of Historic Sites", category: "Recreation", seats: 15 }
];

let selectedCategory = "All";
let searchQueryText = "";

// Helper to log to on-screen console
function logToEventsConsole(message, type = 'info') {
    const consoleBox = document.getElementById('eventsConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Task 8: Use onclick for "Register" buttons
function registerSeat(eventId) {
    const event = interactiveEvents.find(e => e.id === eventId);
    if (event && event.seats > 0) {
        event.seats--;
        logToEventsConsole(`onclick event triggered for ID ${eventId}. Registering seat. Seats left: ${event.seats}`, "success");
        renderEventsBoard();
    } else {
        logToEventsConsole(`onclick event rejected for ID ${eventId}. Event is full!`, "error");
    }
}

// Task 8: Use onchange to filter events by category
function handleCategoryChange(categoryVal) {
    selectedCategory = categoryVal;
    logToEventsConsole(`onchange event triggered on dropdown. Filter category set to: "${categoryVal}"`, "info");
    renderEventsBoard();
}

// Render filtered lists
function renderEventsBoard() {
    const board = document.getElementById('eventsBoard');
    board.innerHTML = '';

    const filtered = interactiveEvents.filter(event => {
        const matchesCategory = (selectedCategory === "All" || event.category === selectedCategory);
        const matchesSearch = event.name.toLowerCase().includes(searchQueryText.toLowerCase());
        return matchesCategory && matchesSearch;
    });

    if (filtered.length === 0) {
        board.innerHTML = '<p style="color: var(--text-secondary); text-align: center; font-size: 0.9rem;">No matching events found.</p>';
        return;
    }

    filtered.forEach(event => {
        const card = document.createElement('div');
        card.className = 'event-card';

        const info = document.createElement('div');
        info.className = 'event-info';
        info.innerHTML = `
            <h3>${event.name} <span class="event-tag" style="font-size:0.65rem; background:rgba(99,102,241,0.1); color:#818cf8;">${event.category}</span></h3>
            <p>Seats Remaining: ${event.seats}</p>
        `;

        const actionArea = document.createElement('div');
        const regBtn = document.createElement('button');
        regBtn.className = 'btn btn-primary';
        regBtn.style.padding = '0.4rem 1rem';
        regBtn.style.fontSize = '0.8rem';
        regBtn.textContent = event.seats === 0 ? 'Full' : 'Register';
        if (event.seats === 0) regBtn.disabled = true;

        // Bind onclick handler
        regBtn.onclick = () => registerSeat(event.id);

        actionArea.appendChild(regBtn);
        card.appendChild(info);
        card.appendChild(actionArea);

        board.appendChild(card);
    });
}

// Bind search on keydown
document.addEventListener('DOMContentLoaded', () => {
    const searchBar = document.getElementById('searchBar');
    
    // Task 8: Use keydown to allow quick search by name
    searchBar.addEventListener('keydown', (event) => {
        // Log the key pressed to show interaction in console
        logToEventsConsole(`keydown event: Key pressed is "${event.key}"`, "info");
        
        // Use setTimeout(..., 0) so the input's new text is read correctly (keydown fires before character is inserted)
        setTimeout(() => {
            searchQueryText = searchBar.value;
            logToEventsConsole(`Search query updated to: "${searchQueryText}"`, "success");
            renderEventsBoard();
        }, 0);
    });

    logToEventsConsole("Event Handling script loaded. onclick, onchange, and keydown listeners ready.", "success");
    renderEventsBoard();
});
