// Animate skill bars on scroll
document.addEventListener('DOMContentLoaded', () => {
    const skillFills = document.querySelectorAll('.skill-fill');

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.width = entry.target.style.width || '0%';
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.3 });

    skillFills.forEach(fill => {
        const targetWidth = fill.style.width;
        fill.style.width = '0%';
        fill.dataset.target = targetWidth;
        observer.observe(fill);

        // Animate after a short delay
        setTimeout(() => {
            fill.style.width = targetWidth;
        }, 200);
    });

    // Add active state to current nav link
    const currentPath = window.location.pathname.toLowerCase();
    document.querySelectorAll('.nav-link').forEach(link => {
        const href = link.getAttribute('href');
        if (href && currentPath.startsWith(href.toLowerCase()) && href !== '/') {
            link.classList.add('active');
            link.style.color = 'var(--clr-accent)';
        }
    });
});
