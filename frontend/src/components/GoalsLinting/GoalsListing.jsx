import GoalCard from "../GoalCard/GoalCard";

function GoalsListing({ goals }) { return (
  <div className="row g-4">
    {goals.map(goal => (
      <div
        key={goal.id}
        className="col-12 col-sm-6 col-md-4 custom-col"
      >
        <GoalCard goal={goal} />
      </div>
    ))}
  </div>
	)
}

export default GoalsListing;