(function () {
    document.addEventListener('click', (event) => {
        const menuButton = event.target.closest('[data-open-menu]');

        if (menuButton) {
            const menuId = menuButton.dataset.openMenu;
            const menu = document.getElementById(menuId);

            if (!menu) {
                return;
            }

            document.querySelectorAll('[data-open-menu]').forEach(button => {
                const otherMenuId = button.dataset.openMenu;
                const otherMenu = document.getElementById(otherMenuId);

                if (otherMenu && otherMenu !== menu) {
                    otherMenu.classList.add('hidden');
                }
            });

            menu.classList.toggle('hidden');

            return;
        }

        if (!event.target.closest("[id^='medicine-menu-']")) {
            document
                .querySelectorAll("[id^='medicine-menu-']")
                .forEach(menu => {
                    menu.classList.add('hidden');
                });
        }
    });
})();