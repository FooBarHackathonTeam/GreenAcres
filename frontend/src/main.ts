import './app.css';
import App from './App.svelte';

window.onerror = (message, url, line) => {
    alert(`${message}, ${url}, ${line}`);
};

window.onmessage = (message) => {
    alert(message);
};

window.onmessageerror = (message) => {
    alert(message);
}

const app = new App({
    target: document.getElementById('app'),
});

export default app;
