// Helper to log to on-screen console
function logToAjaxConsole(message, type = 'info') {
    const consoleBox = document.getElementById('ajaxConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('ajaxForm');
    const submitBtn = document.getElementById('submitBtn');
    const progressBarContainer = document.getElementById('progressBarContainer');
    const progressBar = document.getElementById('progressBar');
    const responseContainer = document.getElementById('ajaxResponseContainer');

    form.addEventListener('submit', (event) => {
        event.preventDefault();

        const name = document.getElementById('ajaxName').value.trim();
        const email = document.getElementById('ajaxEmail').value.trim();

        logToAjaxConsole(`Form submitted. Name: "${name}", Email: "${email}"`, "info");
        logToAjaxConsole("Disabling input fields and showing progress bar...", "info");

        // UI states
        submitBtn.disabled = true;
        submitBtn.textContent = "Connecting to Server...";
        progressBarContainer.style.display = 'block';
        responseContainer.innerHTML = '';
        
        // Force width reflow to start transition
        progressBar.style.width = '0%';
        setTimeout(() => {
            progressBar.style.width = '100%';
        }, 50);

        // Task 12: Use setTimeout() to simulate a delayed response
        logToAjaxConsole("Initiating 1.5s simulated network delay via setTimeout()...", "warning");

        setTimeout(() => {
            logToAjaxConsole("Timeout complete. Dispatching fetch POST request...", "info");
            
            const payload = {
                name: name,
                email: email,
                timestamp: new Date().toISOString()
            };

            // Task 12: Use fetch() to POST user data to a mock API
            fetch('https://jsonplaceholder.typicode.com/posts', {
                method: 'POST',
                headers: {
                    'Content-type': 'application/json; charset=UTF-8',
                },
                body: JSON.stringify(payload)
            })
            .then(response => {
                logToAjaxConsole(`POST Request complete. Server response status: ${response.status} (${response.statusText})`, "success");
                if (!response.ok) {
                    throw new Error(`Server returned HTTP ${response.status}`);
                }
                return response.json();
            })
            .then(data => {
                logToAjaxConsole(`Server Response Payload: ${JSON.stringify(data)}`, "success");
                
                // Task 12: Show success/failure message after submission
                responseContainer.innerHTML = `
                    <div class="alert-box alert-success">
                        <strong>Success!</strong> Registration posted to server. (Assigned Database ID: ${data.id})
                    </div>
                `;
                
                form.reset();
                resetFormUI();
            })
            .catch(error => {
                logToAjaxConsole(`Fetch transaction failed: ${error.message}`, "error");
                
                // Task 12: Show success/failure message after submission
                responseContainer.innerHTML = `
                    <div class="alert-box alert-error">
                        <strong>Network Failure:</strong> Failed to post registry data. ${error.message}
                    </div>
                `;
                resetFormUI();
            });

        }, 1500);
    });

    function resetFormUI() {
        submitBtn.disabled = false;
        submitBtn.textContent = "Register User (POST Request)";
        progressBarContainer.style.display = 'none';
        progressBar.style.width = '0%';
    }

    logToAjaxConsole("AJAX registration listener online.", "success");
});
