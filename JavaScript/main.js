// Task 1: Log message to browser console
console.log("Welcome to the Community Portal");

// Helper function to append logs to the on-screen console
function logToScreen(message, type = 'info') {
    const consoleBox = document.getElementById('onScreenConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Log initial message to on-screen console
document.addEventListener('DOMContentLoaded', () => {
    logToScreen("HTML parsed, DOM fully loaded.", "success");
    logToScreen("Console.log executed: 'Welcome to the Community Portal'", "info");
});

// Task 1: Use alert to notify when the page is fully loaded
window.addEventListener('load', () => {
    logToScreen("Window fully loaded (including resources). Triggering alert...", "warning");
    // Use setTimeout so the alert doesn't block the initial rendering of the page
    setTimeout(() => {
        alert("Welcome to the Community Portal!");
        logToScreen("Alert dismissed.", "success");
    }, 100);
});

// Interactivity: trigger alert manually
function triggerAlert() {
    logToScreen("Alert triggered manually by user.", "info");
    alert("Welcome to the Community Portal! (Manual Trigger)");
}
