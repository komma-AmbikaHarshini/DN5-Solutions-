// Task 5: Define Event constructor
function CommunityEvent(name, date, seats, totalSeats) {
    this.name = name;
    this.date = date;
    this.seats = parseInt(seats) || 0;
    this.totalSeats = parseInt(totalSeats) || 0;
}

// Task 5: Add checkAvailability() to prototype
CommunityEvent.prototype.checkAvailability = function() {
    return this.seats > 0;
};

// Helper to log to on-screen console
function logToObjectsConsole(message, type = 'info') {
    const consoleBox = document.getElementById('objectsConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Reference to current active instance
let currentEventInstance = null;

// Instantiate and render properties
function updateLiveObject() {
    const name = document.getElementById('objName').value;
    const date = document.getElementById('objDate').value;
    const seats = document.getElementById('objSeats').value;
    const totalSeats = document.getElementById('objTotal').value;

    // Instantiate new Event using constructor
    currentEventInstance = new CommunityEvent(name, date, seats, totalSeats);

    // Call prototype method checkAvailability()
    const isAvailable = currentEventInstance.checkAvailability();
    
    // Update availability badge in HTML
    const badge = document.getElementById('availabilityBadge');
    if (isAvailable) {
        badge.textContent = "AVAILABLE (Seats > 0)";
        badge.style.background = 'rgba(16, 185, 129, 0.1)';
        badge.style.color = '#34d399';
        badge.style.borderColor = 'rgba(16, 185, 129, 0.3)';
    } else {
        badge.textContent = "FULLY BOOKED (Seats = 0)";
        badge.style.background = 'rgba(239, 68, 68, 0.1)';
        badge.style.color = '#f87171';
        badge.style.borderColor = 'rgba(239, 68, 68, 0.3)';
    }

    // Task 5: List object keys and values using Object.entries()
    const tableBody = document.getElementById('entriesTableBody');
    tableBody.innerHTML = '';
    
    const entries = Object.entries(currentEventInstance);
    
    entries.forEach(([key, value]) => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td style="color: var(--accent-hover); font-weight: 500;"><code>${key}</code></td>
            <td><code>${value}</code></td>
        `;
        tableBody.appendChild(row);
    });
}

// Log action to console when inputs change
let changeTimeout;
document.addEventListener('DOMContentLoaded', () => {
    logToObjectsConsole("CommunityEvent constructor defined.", "info");
    logToObjectsConsole("checkAvailability() added to CommunityEvent.prototype.", "info");
    
    updateLiveObject();
    logToObjectsConsole("Initial Event object instantiated and Object.entries() rendered.", "success");

    // Add logging to input changes, debounced
    const inputs = ['objName', 'objDate', 'objSeats', 'objTotal'];
    inputs.forEach(id => {
        document.getElementById(id).addEventListener('input', () => {
            clearTimeout(changeTimeout);
            changeTimeout = setTimeout(() => {
                logToObjectsConsole(`Object updated. Prototype checkAvailability() => ${currentEventInstance.checkAvailability()}`, "info");
                logToObjectsConsole(`Object.entries() count: ${Object.entries(currentEventInstance).length}`, "success");
            }, 500);
        });
    });
});
