async function sendPOSTJSON(url: string, data: Object) {
    const response = await fetch(url, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    });
    const jsonData = await response.json();
    return jsonData;
}
