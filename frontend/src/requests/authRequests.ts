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

export async function sendJsonAuth(url: string, method: string, token: string, data: Object) {
  const response = await fetch(url, {
    method,
    body: JSON.stringify(data),
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`
    },
  });
  const jsonData = await response.json();
  return jsonData;
}

export async function getJsonAuth(url: string, token: string) {
  const response = await fetch(url, {
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
        "Authorization": `Bearer ${token}`
    },
  });
  const jsonData = await response.json();
  return jsonData;
}
