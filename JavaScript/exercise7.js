const domEventsData = [
    { id: 101, name: "Community Yoga in the Park", date: "Every Saturday", seats: 15, maxSeats: 15 },
    { id: 102, name: "Local Writers Circle Meetup", date: "Oct 29, 2026", seats: 8, maxSeats: 10 },
    { id: 103, name: "Kids Pottery Workshop", date: "Nov 05, 2026", seats: 2, maxSeats: 12 }
];

// Helper to log to on-screen console
function logToDomConsole(message, type = 'info') {
    const consoleBox = document.getElementById('domConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Render using document.querySelector and document.createElement
function buildDOMBoard() {
    // Task 7: Access DOM elements using querySelector()
    const container = document.querySelector('#domBoardContainer');
    container.innerHTML = '';
    
    logToDomConsole("Accessing DOM container: document.querySelector('#domBoardContainer')", "info");

    domEventsData.forEach(event => {
        // Task 7: Create event cards using createElement()
        const card = document.createElement('div');
        card.className = 'event-card';
        card.setAttribute('data-id', event.id);

        const info = document.createElement('div');
        info.className = 'event-info';

        const nameElement = document.createElement('h3');
        nameElement.textContent = event.name;

        const detailsElement = document.createElement('p');
        // Let's create a dedicated span for the seat number so we can query/edit it easily
        detailsElement.innerHTML = `Date: ${event.date} | Available: <span class="seat-count" style="font-weight:600; color:var(--success-color);">${event.seats}</span> / ${event.maxSeats}`;

        info.appendChild(nameElement);
        info.appendChild(detailsElement);

        const btnGroup = document.createElement('div');
        btnGroup.style.display = 'flex';
        btnGroup.style.gap = '0.5rem';

        const registerBtn = document.createElement('button');
        registerBtn.className = 'btn btn-primary';
        registerBtn.style.padding = '0.4rem 0.8rem';
        registerBtn.style.fontSize = '0.8rem';
        registerBtn.textContent = 'Register';
        if (event.seats <= 0) registerBtn.disabled = true;

        const cancelBtn = document.createElement('button');
        cancelBtn.className = 'btn btn-secondary';
        cancelBtn.style.padding = '0.4rem 0.8rem';
        cancelBtn.style.fontSize = '0.8rem';
        cancelBtn.textContent = 'Cancel';
        if (event.seats >= event.maxSeats) cancelBtn.disabled = true;

        // Task 7: Update UI when user registers or cancels
        registerBtn.addEventListener('click', () => {
            if (event.seats > 0) {
                event.seats--;
                logToDomConsole(`Registration registered for ID ${event.id}. Seats decremented to ${event.seats}.`, "success");
                
                // Locate elements inside the specific card
                const seatSpan = card.querySelector('.seat-count');
                seatSpan.textContent = event.seats;
                
                // Adjust button disabled states
                if (event.seats === 0) registerBtn.disabled = true;
                cancelBtn.disabled = false;
            }
        });

        cancelBtn.addEventListener('click', () => {
            if (event.seats < event.maxSeats) {
                event.seats++;
                logToDomConsole(`Registration cancelled for ID ${event.id}. Seats incremented to ${event.seats}.`, "warning");
                
                // Locate elements inside the specific card
                const seatSpan = card.querySelector('.seat-count');
                seatSpan.textContent = event.seats;
                
                // Adjust button disabled states
                if (event.seats === event.maxSeats) cancelBtn.disabled = true;
                registerBtn.disabled = false;
            }
        });

        btnGroup.appendChild(registerBtn);
        btnGroup.appendChild(cancelBtn);

        card.appendChild(info);
        card.appendChild(btnGroup);

        // Append to parent container
        container.appendChild(card);
        logToDomConsole(`Appended card to DOM: createElement('div') -> appendChild() for event "${event.name}"`, "success");
    });
}

// Run on load
document.addEventListener('DOMContentLoaded', () => {
    buildDOMBoard();
});
