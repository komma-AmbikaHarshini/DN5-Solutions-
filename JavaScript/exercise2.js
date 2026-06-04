// Task 2: Declare variables using const (event details) and let (changeable seat count)
const eventName = "Local Music & Food Carnival";
const eventDate = "October 24, 2026";
let availableSeats = 45;

// Helper to log to on-screen console
function logToSyntaxConsole(message, type = 'info') {
    const consoleBox = document.getElementById('syntaxConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Task 2: Concatenate event info using template literals
function updateEventUI() {
    const eventDescription = `The event "${eventName}" is scheduled to happen on ${eventDate}. There are currently ${availableSeats} seats remaining.`;
    
    // Update HTML elements
    document.getElementById('eventDescription').textContent = eventDescription;
    document.getElementById('dispName').textContent = eventName;
    document.getElementById('dispDate').textContent = eventDate;
    document.getElementById('dispSeats').textContent = availableSeats;
}

// Task 2: Use ++ or -- to manage seat count
function bookSeat() {
    if (availableSeats > 0) {
        availableSeats--; // Decrement seats
        logToSyntaxConsole(`User registered. Seats decremented (seats--). New available seats: ${availableSeats}`, "success");
        updateEventUI();
    } else {
        logToSyntaxConsole(`Cannot register. Available seats: ${availableSeats}. Event is full!`, "error");
    }
}

function cancelSeat() {
    // Add dynamic checking so seats don't exceed a reasonable max (e.g. 50)
    if (availableSeats < 50) {
        availableSeats++; // Increment seats
        logToSyntaxConsole(`Registration cancelled. Seats incremented (seats++). New available seats: ${availableSeats}`, "info");
        updateEventUI();
    } else {
        logToSyntaxConsole(`Seats are already at maximum capacity!`, "warning");
    }
}

// Initial UI load
document.addEventListener('DOMContentLoaded', () => {
    logToSyntaxConsole("Variables initialized: const eventName, const eventDate, let availableSeats = 45", "info");
    updateEventUI();
});
