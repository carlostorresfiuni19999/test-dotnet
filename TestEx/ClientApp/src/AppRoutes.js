import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { GetTodos } from "./components/GetTodos";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/to-dos',
        element: <GetTodos />
    }
];

export default AppRoutes;
