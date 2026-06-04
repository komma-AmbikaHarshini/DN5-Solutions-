// Helper to log to on-screen console
function logToDebugConsole(message, type = 'info') {
    const consoleBox = document.getElementById('debugConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Global state variables for debugger inspection
let buggyMode = true;

function toggleBugState() {
    buggyMode = document.getElementById('buggyToggle').checked;
    const alertBox = document.getElementById('debugStatusAlert');
    
    if (buggyMode) {
        alertBox.innerHTML = `
            <div class="alert-box alert-warning">
                <strong>Mode:</strong> Buggy Mode Active. Submission will fail silently. Open Chrome Dev Tools (Console) to inspect.
            </div>
        `;
        logToDebugConsole("Buggy Mode Activated. Silent error is now primed.", "warning");
    } else {
        alertBox.innerHTML = `
            <div class="alert-box alert-success">
                <strong>Mode:</strong> Fixed Mode Active. Errors resolved.
            </div>
        `;
        logToDebugConsole("Fixed Mode Activated. Exception handling and payloads verified.", "success");
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('debugForm');
    const varInspector = document.getElementById('variableInspector');
    const networkLog = document.getElementById('networkTabLog');
    const alertBox = document.getElementById('debugStatusAlert');

    toggleBugState();

    form.addEventListener('submit', (event) => {
        event.preventDefault();
        
        // Log submission steps to actual developer tools console as per spec
        console.group("Registration Form Submission Process");
        console.log("%cStep 1: Capturing inputs...", "color: #38bdf8; font-weight: bold;");
        logToDebugConsole("Step 1: Capturing inputs from form...", "info");

        const rawName = document.getElementById('dbgName').value;
        const rawEmail = document.getElementById('dbgEmail').value;

        console.log(`Captured values -> name: "${rawName}", email: "${rawEmail}"`);

        // Task 13: Simulated Silent Failure & Variable Inspection
        if (buggyMode) {
            console.log("%cStep 2: Simulating uncaught reference exception...", "color: #ef4444; font-weight: bold;");
            
            // Intentionally log error to real developer tools console to mimic silent crash
            console.error("Uncaught ReferenceError: payloadData is not defined at HTMLFormElement.<anonymous> (exercise13.js:54)");
            logToDebugConsole("EXCEPTION OCCURRED: Silent failure triggered. UI rendering interrupted.", "error");
            logToDebugConsole("Check your browser Console tab (F12) to inspect the error details!", "warning");

            // Update on-screen variable inspector
            // Task 13: Add breakpoints and inspect variables mockup
            varInspector.innerHTML = `
// Breakpoint hit at line 48 in exercise13.js (Buggy Mode)
Local Scope:
  rawName: "${rawName}"
  rawEmail: "${rawEmail}"
  payloadData: <undefined> (ReferenceError: payloadData is not defined)
  
Global Scope:
  buggyMode: ${buggyMode}
            `;

            networkLog.innerHTML = `
HTTP POST https://api.communityportal.org/register
Status: (Failed)
Payload:
  [No payload sent - Connection aborted due to Uncaught Exception]
            `;
            
            console.groupEnd();
            return;
        }

        // Fixed Mode
        console.log("%cStep 2: Validating inputs...", "color: #34d399; font-weight: bold;");
        logToDebugConsole("Step 2: Checking variable definitions...", "info");

        // Construct valid payload
        const payloadData = {
            name: rawName,
            email: rawEmail,
            submittedAt: new Date().toISOString()
        };

        console.log("%cStep 3: Payload constructed.", "color: #34d399; font-weight: bold;");
        console.dir(payloadData);
        logToDebugConsole("Step 3: Constructing registration payload.", "success");

        // Task 13: Log form submission steps and check fetch request payload
        varInspector.innerHTML = `
// Breakpoint hit at line 62 in exercise13.js (Fixed Mode)
Local Scope:
  rawName: "${rawName}"
  rawEmail: "${rawEmail}"
  payloadData: {
    name: "${payloadData.name}",
    email: "${payloadData.email}",
    submittedAt: "${payloadData.submittedAt}"
  }

Global Scope:
  buggyMode: ${buggyMode}
        `;

        // Render simulated Network tab request
        networkLog.innerHTML = `
HTTP POST https://api.communityportal.org/register
Status: 201 (Created)
Payload:
${JSON.stringify(payloadData, null, 2)}
        `;

        logToDebugConsole("Step 4: Request successfully logged to network monitor.", "success");
        console.log("%cStep 4: Request sent successfully.", "color: #34d399; font-weight: bold;");
        console.groupEnd();

        // Update UI status
        const originalContent = alertBox.innerHTML;
        alertBox.innerHTML = `
            <div class="alert-box alert-success">
                <strong>Success:</strong> Registration completed! Variables and Network payloads checked.
            </div>
        `;
        
        setTimeout(() => {
            toggleBugState();
        }, 3000);
    });
});
