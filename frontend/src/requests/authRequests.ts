export async function sendJson(url: string, method: string, data: Object) {
  const response = await fetch(url, {
    method,
    body: JSON.stringify(data),
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
  });
  const jsonData = await response.json();
  return jsonData;
}
