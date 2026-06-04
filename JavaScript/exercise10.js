// Task 10: Use const for original list
const originalEvents = [
    { name: "Charity Toy Drive", date: "Dec 10, 2026", category: "Charity", seats: 40 },
    { name: "Advanced CSS Grid Seminar", date: "Nov 02, 2026", category: "Tech", seats: 0 }, // full
    { name: "Coffee Roasting Class", date: "Nov 05, 2026", category: "Education", seats: 15 }
];

// Helper to log to on-screen console
function logToModernConsole(message, type = 'info') {
    const consoleBox = document.getElementById('modernConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Task 10: Use default parameters in functions
function createEventObject(name, date, category = "General", seats = 10) {
    logToModernConsole(`[Default Parameters] category set to: "${category}", seats set to: ${seats}`, "info");
    return {
        name,
        date,
        category,
        seats
    };
}

function createAndRenderModernEvent() {
    const nameVal = document.getElementById('modernName').value.trim();
    const dateVal = document.getElementById('modernDate').value.trim();
    let categoryVal = document.getElementById('modernCategory').value.trim();
    
    if (!nameVal) {
        logToModernConsole("Error: Event name is required.", "error");
        return;
    }

    // If category value is empty, pass undefined to trigger default parameters
    const finalCategory = categoryVal === "" ? undefined : categoryVal;

    // Call function that uses default parameters
    const newEvent = createEventObject(nameVal, dateVal, finalCategory);

    // Task 10: Use destructuring to extract event details
    const { name, date, category, seats } = newEvent;
    logToModernConsole(`[Destructuring] Extracted properties -> Name: "${name}", Category: "${category}"`, "success");

    // Task 10: Use spread operator to clone event list before filtering
    logToModernConsole("Executing: const clonedList = [...originalEvents, newEvent]", "info");
    const clonedList = [...originalEvents, newEvent];
    
    // Demonstrate original list is unchanged (mutability isolation check)
    logToModernConsole(`Original array length: ${originalEvents.length} | Cloned array length: ${clonedList.length}`, "success");

    // Filter cloned list to only display upcoming events with seats > 0
    const availableEvents = clonedList.filter(evt => evt.seats > 0);
    logToModernConsole(`Filtered cloned list for available seats (count: ${availableEvents.length})`, "info");

    renderList(availableEvents);
}

function renderList(list) {
    const container = document.getElementById('clonedEventsList');
    container.innerHTML = '';

    list.forEach(event => {
        // Use destructuring in the loop
        const { name, date, category, seats } = event;
        
        const card = document.createElement('div');
        card.className = 'event-card';
        card.style.padding = '0.75rem 1rem';
        card.style.marginBottom = '0';
        card.innerHTML = `
            <div class="event-info">
                <h4 style="font-family: var(--font-heading); font-size: 0.95rem; font-weight: 500;">${name}</h4>
                <p style="font-size: 0.75rem; color: var(--text-secondary);">${date} | Seats: ${seats}</p>
            </div>
            <div>
                <span class="event-tag" style="font-size:0.65rem; background:rgba(139,92,246,0.15); color:var(--accent-hover);">${category}</span>
            </div>
        `;
        container.appendChild(card);
    });
}

// Initial Run
document.addEventListener('DOMContentLoaded', () => {
    logToModernConsole("Modern JavaScript ES6+ demo loaded.", "success");
    createAndRenderModernEvent();
});
