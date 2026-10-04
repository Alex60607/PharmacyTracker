(function () {
    const profileButton = document.getElementById('profileButton');
    const profileMenu = document.getElementById('profileMenu');

    if (!profileButton || !profileMenu) {
        return;
    }

    profileButton.addEventListener('click', (event) => {
        event.stopPropagation();

        profileMenu.classList.toggle('hidden');

        const isOpen = !profileMenu.classList.contains('hidden');
        profileButton.setAttribute('aria-expanded', isOpen);
    });

    document.addEventListener('click', (event) => {
        if (
            !profileMenu.contains(event.target) &&
            !profileButton.contains(event.target)
        ) {
            profileMenu.classList.add('hidden');
            profileButton.setAttribute('aria-expanded', 'false');
        }
    });
})();