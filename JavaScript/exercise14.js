// Helper to log to on-screen console
function logToJqueryConsole(message, type = 'info') {
    const consoleBox = document.getElementById('jqueryConsole');
    if (consoleBox) {
        const line = document.createElement('div');
        line.className = `console-line ${type}`;
        line.textContent = `[${new Date().toLocaleTimeString()}] ${message}`;
        consoleBox.appendChild(line);
        consoleBox.scrollTop = consoleBox.scrollHeight;
    }
}

// Task 14: Use jQuery to simplify DOM tasks
$(document).ready(function() {
    logToJqueryConsole("jQuery library version " + $.fn.jquery + " loaded successfully.", "success");
    logToJqueryConsole("Document ready callback fired.", "info");

    let isRegistered = false;

    // Task 14: Use $('#registerBtn').click(...) to handle click events
    $('#registerBtn').click(function() {
        logToJqueryConsole("jQuery click event listener $('#registerBtn').click() triggered.", "warning");
        
        const card = $('#animationCard');
        const content = $('#cardContent');
        const button = $('#registerBtn');

        // Task 14: Use .fadeIn() and .fadeOut() for event cards
        logToJqueryConsole("Executing card animation sequence: fadeOut() -> update state -> fadeIn()", "info");

        // Disable button during animation
        button.prop('disabled', true);

        // Fade out transition
        card.fadeOut('slow', function() {
            logToJqueryConsole("fadeOut() completed. Modifying DOM content in memory...", "success");

            if (!isRegistered) {
                // Update to success state
                $('#cardTitleText').text("Registration Confirmed! 🎉");
                content.find('p').text("Thank you for signing up! We've sent a confirmation email to you.");
                button.text("Cancel Registration (jQuery)");
                button.removeClass('btn-primary').addClass('btn-danger');
                isRegistered = true;
            } else {
                // Reset state
                $('#cardTitleText').text("Interactive Baking Workshop");
                content.find('p').text("Join us for an exciting baking event on December 20, 2026.");
                button.text("Register with jQuery ($('#registerBtn').click)");
                button.removeClass('btn-danger').addClass('btn-primary');
                isRegistered = false;
            }

            // Fade back in transition
            card.fadeIn('slow', function() {
                logToJqueryConsole("fadeIn() completed. Animation sequence finished.", "success");
                button.prop('disabled', false);
            });
        });
    });
});
