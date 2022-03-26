import Header from './components/header/Header';
import Footer from './components/footer/Footer';
import Converter from './components/converter/Converter';

function App() {
  return (
    <>
      <div className="container">
        <Header />
      </div>
      <Converter />
      <Footer />
    </>
  );
}

export default App;
