self.addEventListener('push', function (event) {
    const options = {
        body: event.data.text(),
        icon: 'https://en.wikipedia.org/wiki/File:Flag_of_Germany.svg', 
        tag: 'push-notification-tag'
    };

    event.waitUntil(
        self.registration.showNotification('Новое сообщение', options)
    );
});

const backendUrl = 'http://localhost:5296'
self.addEventListener('notificationclick', function (event) {
    event.notification.close();
    event.waitUntil(
        clients.openWindow(backendUrl)
    );
});