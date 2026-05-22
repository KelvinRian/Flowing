const API_URL = 'https://localhost:7068/Goals';

export async function getGoals() {

  const response = await fetch(API_URL);

  if (!response.ok) {
    throw new Error('Erro ao buscar goals');
  }

  return await response.json();
}