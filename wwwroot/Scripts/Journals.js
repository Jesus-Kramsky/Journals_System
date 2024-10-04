function showJournal(button) {
    var iframe = button.nextElementSibling.nextElementSibling;

    if (iframe.hasAttribute('hidden')) {
        iframe.removeAttribute('hidden');
    }

    button.style.display = 'none';

    var hideButton = button.nextElementSibling;
    hideButton.style.display = 'inline-block';
    hideButton.removeAttribute('hidden');
}

function hideJournal(button) {
    var iframe = button.nextElementSibling;

    if (!iframe.hasAttribute('hidden')) {
        iframe.setAttribute('hidden', true);
    }

    var showButton = button.previousElementSibling;
    showButton.style.display = 'inline-block';

    button.style.display = 'none';
}