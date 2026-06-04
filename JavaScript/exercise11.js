// Helper to log to on-screen console
function logToFormsConsole(message, type = 'info') {
    const consoleBox = document.getElementById('formsConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('registrationForm');

    form.addEventListener('submit', (event) => {
        // Task 11: Prevent default form behavior using event.preventDefault()
        event.preventDefault();
        logToFormsConsole("Form submit intercepted. event.preventDefault() executed.", "warning");

        // Task 11: Capture name, email, and selected event using form.elements
        const userNameInput = form.elements['userName'];
        const userEmailInput = form.elements['userEmail'];
        const selectedEventSelect = form.elements['selectedEvent'];

        const nameValue = userNameInput.value.trim();
        const emailValue = userEmailInput.value.trim();
        const eventValue = selectedEventSelect.value;

        logToFormsConsole(`Captured inputs -> Name: "${nameValue}", Email: "${emailValue}", Event ID: "${eventValue}"`, "info");

        // Reset inline errors and borders
        const errorSpans = document.querySelectorAll('.form-error');
        errorSpans.forEach(span => span.style.display = 'none');
        
        const controls = document.querySelectorAll('.form-control');
        controls.forEach(ctrl => ctrl.classList.remove('is-invalid'));

        let isValid = true;

        // Task 11: Validate inputs and show errors inline
        // 1. Name validation (at least 3 characters)
        if (nameValue.length < 3) {
            userNameInput.classList.add('is-invalid');
            document.getElementById('nameError').style.display = 'block';
            logToFormsConsole("Validation failed: Name is too short (min 3 chars).", "error");
            isValid = false;
        }

        // 2. Email validation (regex)
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(emailValue)) {
            userEmailInput.classList.add('is-invalid');
            document.getElementById('emailError').style.display = 'block';
            logToFormsConsole("Validation failed: Invalid email format.", "error");
            isValid = false;
        }

        // 3. Event validation (must select one)
        if (eventValue === "") {
            selectedEventSelect.classList.add('is-invalid');
            document.getElementById('eventError').style.display = 'block';
            logToFormsConsole("Validation failed: No event selected.", "error");
            isValid = false;
        }

        if (isValid) {
            logToFormsConsole("All form inputs verified successfully!", "success");
            
            // Render success alert
            const alertBox = document.getElementById('formSuccessAlert');
            alertBox.innerHTML = `
                <div class="alert-box alert-success">
                    <strong>Success!</strong> You have successfully registered for the event.
                </div>
            `;

            // Reset fields
            form.reset();

            // Clear success alert after 4 seconds
            setTimeout(() => {
                alertBox.innerHTML = '';
            }, 4000);
        } else {
            logToFormsConsole("Form contains errors. Submission rejected.", "error");
        }
    });

    logToFormsConsole("Form handlers bound to registrationForm.", "success");
});
