import './GoalCard.css';

function GoalCard({ goal }) { return (
    <div className="goal-card">                
      <div className="goal-card-title">
        {goal.title}
      </div>
      <div className="goal-card-progress">
        <strong>
          {String(goal.completed).padStart(2, '0')}/
          {String(goal.total).padStart(2, '0')}
        </strong>
        {' '}tarefas concluídas
      </div>
    </div>
	)
}

export default GoalCard;