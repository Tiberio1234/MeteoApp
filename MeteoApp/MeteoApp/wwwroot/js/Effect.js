
function applyWeatherEffect(effect) {
    const container = document.getElementById('weather-container');
    if (effect === 'sunny') {
        container.classList.remove('rainy-effect');
        container.classList.add('sunny-effect');
    } else if (effect === 'rainy') {
        container.classList.remove('sunny-effect');
        container.classList.add('rainy-effect');
    }
}

