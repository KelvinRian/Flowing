import GoalsListing from "../../components/GoalsLinting/GoalsListing";
import './HomeScreen.css';

const goals = [
  {
    id: 1,
    title: 'Maratonar Shrek',
    completed: 0,
    total: 4
  },
  {
    id: 2,
    title: 'Projeto Flowing',
    completed: 3,
    total: 8
  },
  {
    id: 3,
    title: 'Melhorar Inglês',
    completed: 10,
    total: 15
  },
  {
    id: 4,
    title: 'Maratonar Shrek de novo',
    completed: 0,
    total: 4
  },
  {
    id: 5,
    title: 'Rebaixar o Pálio',
    completed: 5,
    total: 9
  }
];

function HomeScreen() {
  return (
    <div className="home-screen-page">
      <div className="container-fluid h-100 py-5 px-4">
        <GoalsListing goals={goals} />
      </div>
    </div>
  )
}

export default HomeScreen;