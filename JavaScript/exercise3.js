// Task 3: Mock event array
const eventsList = [
    { id: 1, name: "Community Tech Hackathon", date: "Oct 12, 2026", seats: 5, status: "upcoming" },
    { id: 2, name: "Baking Masterclass", date: "Sep 01, 2026", seats: 0, status: "upcoming" }, // Full
    { id: 3, name: "Youth Chess Championship", date: "Jan 15, 2026", seats: 15, status: "past" }, // Past
    { id: 4, name: "Charity Art Auction", date: "Nov 20, 2026", seats: 12, status: "upcoming" },
    { id: 5, name: "Neighborhood Cleaning", date: "Dec 05, 2026", seats: 0, status: "upcoming" } // Full
];

// Helper to log to on-screen console
function logToConditionalsConsole(message, type = 'info') {
    const consoleBox = document.getElementById('conditionalsConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Display alert message on screen
function showAlert(message, type = 'success') {
    const alertBoxContainer = document.getElementById('alertBoxContainer');
    alertBoxContainer.innerHTML = `
        <div class="alert-box alert-${type}">
            <strong>${type === 'success' ? 'Success:' : 'Error:'}</strong> ${message}
        </div>
    `;
    // Clear alert after 4 seconds
    setTimeout(() => {
        alertBoxContainer.innerHTML = '';
    }, 4000);
}

// Task 3: Loop through events list using forEach() and check status with if-else
function displayEvents() {
    const activeGrid = document.getElementById('activeEventsGrid');
    const hiddenGrid = document.getElementById('hiddenEventsGrid');
    
    activeGrid.innerHTML = '';
    hiddenGrid.innerHTML = '';
    
    logToConditionalsConsole("Looping through events using eventsList.forEach()...", "info");

    eventsList.forEach(event => {
        // Task 3: Use if-else to filter/hide past or full events
        if (event.status === "past") {
            logToConditionalsConsole(`Filtered out "${event.name}" (Reason: Past Event)`, "warning");
            hiddenGrid.appendChild(createEventCardHTML(event, "Past Event"));
        } else if (event.seats <= 0) {
            logToConditionalsConsole(`Filtered out "${event.name}" (Reason: Fully Booked)`, "warning");
            hiddenGrid.appendChild(createEventCardHTML(event, "Fully Booked"));
        } else {
            logToConditionalsConsole(`Displayed "${event.name}" (Seats: ${event.seats})`, "success");
            activeGrid.appendChild(createEventCardHTML(event, null));
        }
    });
}

function createEventCardHTML(event, filterReason) {
    const card = document.createElement('div');
    card.className = 'event-card';
    
    const info = document.createElement('div');
    info.className = 'event-info';
    info.innerHTML = `
        <h3>${event.name}</h3>
        <p>Date: ${event.date} | Available Seats: ${event.seats}</p>
    `;
    
    const actionArea = document.createElement('div');
    if (filterReason) {
        const badge = document.createElement('span');
        badge.className = 'event-tag';
        badge.style.background = 'rgba(239, 68, 68, 0.1)';
        badge.style.color = '#f87171';
        badge.style.borderColor = 'rgba(239, 68, 68, 0.3)';
        badge.textContent = filterReason;
        actionArea.appendChild(badge);
    } else {
        const button = document.createElement('button');
        button.className = 'btn btn-primary';
        button.style.padding = '0.4rem 1rem';
        button.style.fontSize = '0.8rem';
        button.textContent = 'Register';
        button.onclick = () => attemptRegistration(event.id);
        actionArea.appendChild(button);
    }
    
    card.appendChild(info);
    card.appendChild(actionArea);
    return card;
}

// Task 3: Wrap registration logic in try-catch to handle errors
function attemptRegistration(eventId) {
    const event = eventsList.find(e => e.id === eventId);
    
    logToConditionalsConsole(`Attempting registration for "${event.name}"...`, "info");
    
    try {
        // Condition for throwing error
        if (!event) {
            throw new Error("Event not found in repository.");
        }
        if (event.status === "past") {
            throw new Error(`Cannot register. "${event.name}" is a past event.`);
        }
        if (event.seats <= 0) {
            throw new Error(`Registration failed! "${event.name}" is fully booked.`);
        }
        
        // Success case
        event.seats--;
        logToConditionalsConsole(`Registration successful for "${event.name}". Seats left: ${event.seats}`, "success");
        showAlert(`Successfully registered for ${event.name}!`, "success");
        displayEvents(); // Refresh view
        
    } catch (error) {
        // Handle error gracefully
        logToConditionalsConsole(`Caught Error in try-catch: ${error.message}`, "error");
        showAlert(error.message, "error");
    }
}

// Initialize
document.addEventListener('DOMContentLoaded', () => {
    displayEvents();
});
