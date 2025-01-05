let currentIndex = 0;

function moveSlide(step) {
    const slides = document.querySelector('.slider');
    const totalSlides = document.querySelectorAll('.slide').length;

    currentIndex = (currentIndex + step + totalSlides) % totalSlides;

    slides.style.transform = 'translateX(' + (-currentIndex * 100) + '%)';
}