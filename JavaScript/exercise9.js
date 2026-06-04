// Helper to log to on-screen console
function logToAsyncConsole(message, type = 'info') {
    const consoleBox = document.getElementById('asyncConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

const spinner = document.getElementById('loadingSpinner');
const resultsContainer = document.getElementById('apiResults');

function showSpinner() {
    spinner.style.display = 'block';
    resultsContainer.innerHTML = '';
}

function hideSpinner() {
    spinner.style.display = 'none';
}

function clearResults() {
    resultsContainer.innerHTML = '<p style="color: var(--text-secondary); text-align: center; font-size: 0.9rem;">No data loaded. Press a button to fetch.</p>';
    logToAsyncConsole("Board cleared.", "info");
}

function renderData(data) {
    resultsContainer.innerHTML = '';
    data.forEach(event => {
        const card = document.createElement('div');
        card.className = 'event-card';
        card.innerHTML = `
            <div class="event-info">
                <h3>${event.name}</h3>
                <p>Location: ${event.location} | Date: ${event.date}</p>
            </div>
            <div>
                <span class="event-tag">${event.seats} Seats</span>
            </div>
        `;
        resultsContainer.appendChild(card);
    });
    logToAsyncConsole("Fetched data rendered to the UI board.", "success");
}

function renderError(error) {
    resultsContainer.innerHTML = `
        <div class="alert-box alert-error">
            <strong>Fetch Error:</strong> Unable to retrieve mock events. ${error.message}
        </div>
    `;
    logToAsyncConsole(`Error rendering failed: ${error.message}`, "error");
}

// Task 9: Fetch events from mock JSON endpoint using .then() and .catch()
function loadWithPromises() {
    showSpinner();
    logToAsyncConsole("Initiating fetch using Promises (.then / .catch)...", "info");

    fetch('mock_events.json')
        .then(response => {
            logToAsyncConsole("Response headers received. Status code: " + response.status, "info");
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            logToAsyncConsole("JSON parsed successfully. Simulating 1.2s network latency...", "info");
            // Simulate delay to show loading spinner
            return new Promise(resolve => {
                setTimeout(() => {
                    resolve(data);
                }, 1200);
            });
        })
        .then(data => {
            hideSpinner();
            logToAsyncConsole("Promise chain completed successfully.", "success");
            renderData(data);
        })
        .catch(error => {
            hideSpinner();
            logToAsyncConsole(`.catch block caught error: ${error.message}`, "error");
            renderError(error);
        });
}

// Task 9: Rewrite using async/await and show loading spinner
async function loadWithAsyncAwait() {
    showSpinner();
    logToAsyncConsole("Initiating fetch using async/await syntax...", "info");

    try {
        const response = await fetch('mock_events.json');
        logToAsyncConsole(`Await Fetch complete. Status: ${response.status}`, "info");

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        logToAsyncConsole("Await JSON parse complete. Simulating 1.2s network latency...", "info");

        // Simulate delay to show loading spinner
        await new Promise(resolve => setTimeout(resolve, 1200));

        logToAsyncConsole("Async execution completed successfully.", "success");
        renderData(data);
    } catch (error) {
        logToAsyncConsole(`Try-Catch caught error: ${error.message}`, "error");
        renderError(error);
    } finally {
        hideSpinner();
        logToAsyncConsole("Async/Await finally block executed. Spinner hidden.", "info");
    }
}

// Initial Log
document.addEventListener('DOMContentLoaded', () => {
    logToAsyncConsole("Asynchronous Event Handler initialized. Ready to perform fetches.", "success");
});
