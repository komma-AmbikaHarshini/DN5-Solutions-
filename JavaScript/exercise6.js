// Task 6: Initial event list array
const communityEvents = [
    { title: "Guitar Lessons for Beginners", category: "Music" },
    { title: "Sourdough Baking Masterclass", category: "Workshop" },
    { title: "Community Boardgame Mixer", category: "Social" },
    { title: "Jazz and Wine Evening", category: "Music" },
    { title: "5K Charity Morning Run", category: "Sports" }
];

let activeFilter = "All"; // Can be "All" or "Music"

// Helper to log to on-screen console
function logToArraysConsole(message, type = 'info') {
    const consoleBox = document.getElementById('arraysConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Task 6: Add new events using .push()
function pushEvent() {
    const titleInput = document.getElementById('arrTitle');
    const categorySelect = document.getElementById('arrCategory');
    const title = titleInput.value.trim();
    const category = categorySelect.value;

    if (!title) {
        logToArraysConsole("Error: Event title cannot be empty.", "error");
        return;
    }

    const newEvent = { title, category };
    
    // Push operation
    communityEvents.push(newEvent);
    logToArraysConsole(`Array operation: communityEvents.push({ title: "${title}", category: "${category}" })`, "success");
    logToArraysConsole(`Array length is now: ${communityEvents.length}`, "info");
    
    titleInput.value = ''; // Reset input
    renderList();
}

function setFilter(filterType) {
    activeFilter = filterType;
    
    const btnAll = document.getElementById('btnFilterAll');
    const btnMusic = document.getElementById('btnFilterMusic');
    
    if (filterType === "All") {
        btnAll.className = 'btn btn-primary';
        btnMusic.className = 'btn btn-secondary';
    } else {
        btnAll.className = 'btn btn-secondary';
        btnMusic.className = 'btn btn-primary';
    }

    logToArraysConsole(`Filter changed to: "${filterType}"`, "info");
    renderList();
}

// Render array using .filter() and .map()
function renderList() {
    let listToRender = communityEvents;

    // Task 6: Use .filter() to filter for music events
    if (activeFilter === "Music") {
        logToArraysConsole("Executing: communityEvents.filter(e => e.category === 'Music')", "info");
        listToRender = communityEvents.filter(event => event.category === "Music");
    }

    const container = document.getElementById('formattedCardsList');
    container.innerHTML = '';

    if (listToRender.length === 0) {
        container.innerHTML = '<p style="color: var(--text-secondary); text-align: center; font-size: 0.9rem;">No events found.</p>';
        return;
    }

    // Task 6: Use .map() to format display cards (e.g. "Workshop on Baking")
    logToArraysConsole(`Executing: listToRender.map(e => formattedHTML)`, "info");
    
    const mappedHTML = listToRender.map(event => {
        // Format text slightly, e.g., category inside a tag, custom title format
        const formatTitle = event.category === "Music" ? `🎵 ${event.title}` : `⭐ ${event.title}`;
        return `
            <div class="event-card" style="padding: 0.75rem 1rem; margin-bottom: 0;">
                <div class="event-info">
                    <h4 style="font-family: var(--font-heading); font-size: 0.95rem; font-weight: 500;">${formatTitle}</h4>
                    <p style="font-size: 0.75rem; color: var(--text-secondary);">Category: ${event.category}</p>
                </div>
            </div>
        `;
    });

    // Join mapped array and inject into DOM
    container.innerHTML = mappedHTML.join('');
}

// Initial Render
document.addEventListener('DOMContentLoaded', () => {
    logToArraysConsole("Array initialized with 5 starter elements.", "info");
    setFilter("All");
});
