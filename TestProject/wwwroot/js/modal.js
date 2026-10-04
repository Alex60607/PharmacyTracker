(function () {
    function getPanel(modal) {
        return modal.querySelector('.js-modal-panel');
    }

    function openModal(modal) {
        modal.classList.remove('hidden');

        const panel = getPanel(modal);

        if (panel) {
            panel.classList.remove('modal-enter');

            requestAnimationFrame(() => {
                panel.classList.add('modal-enter');
            });
        }

        document.body.classList.add('overflow-hidden');
    }

    function closeModal(modal) {
        modal.classList.add('hidden');

        const panel = getPanel(modal);

        if (panel) {
            panel.classList.remove('modal-enter');
        }

        document.body.classList.remove('overflow-hidden');
    }

    document.addEventListener('click', (event) => {
        const opener = event.target.closest('[data-open-modal]');

        if (opener) {
            const modal = document.getElementById(opener.dataset.openModal);

            if (modal) {
                openModal(modal);
            }

            return;
        }

        const closer = event.target.closest('[data-close-modal]');

        if (closer) {
            const modal = closer.closest('.js-modal');

            if (modal) {
                closeModal(modal);
            }

            return;
        }

        if (
            event.target.classList.contains('js-modal') &&
            !event.target.classList.contains('hidden')
        ) {
            closeModal(event.target);
        }
    });

    document.addEventListener('keydown', (event) => {
        if (event.key !== 'Escape') {
            return;
        }

        document
            .querySelectorAll('.js-modal:not(.hidden)')
            .forEach(closeModal);
    });
    window.openModal = openModal;
})();