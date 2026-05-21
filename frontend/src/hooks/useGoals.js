import { useEffect, useState } from "react";
import { getGoals } from "../services/goalsService";

export function useGoals() {
    const [goals, setGoals] = useState([]);
    const [loading, setLoading] = useState(true);
		const [error, setError] = useState(null);

    useEffect(() => {
			async function loadItems() {
				try {
					const data = await getGoals();

					const mapped = data.map((goal) => ({
						id: goal.id,
						title: goal.title,
						status: goal.status,
					}));

					setGoals(mapped);
				} catch (err) {
					setError(err.message);
				} finally {
					setLoading(false);
				}
			}

			loadItems();
    }, []);
    return { goals, loading, error};
}