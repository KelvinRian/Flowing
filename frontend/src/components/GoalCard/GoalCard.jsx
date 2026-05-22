import './GoalCard.css';

function GoalCard({ goal }) { return (
    <div className="goal-card">                
      <div className="goal-card-title">
        {goal.title}
      </div>
      <div className="goal-card-progress">
        <strong>
          {goal.numberOfCompletedActions}/
          {goal.totalActions}
        </strong>
        {' '}tarefas concluídas
      </div>
    </div>
	)
}

export default GoalCard;