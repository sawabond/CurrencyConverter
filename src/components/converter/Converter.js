import React, { useEffect, useState } from 'react';
import './Converter.css';
import CurrencyRow from '../../CurrencyRow';
import CurrencyArrow from '../../img/arrows.png';
const URL = 'https://localhost:44341/api/Currency';

const API_CALL_TIMESTAMP = 1000 * 60 * 10; // 10 minutes

let localStoredData = new Map();

let isApiCalling = false;

let toAmount, fromAmount;
function Converter() {
  const [currencyOptions, setCurrencyOptions] = useState([]);
  const [fromCurrency, setFromCurrency] = useState('EUR');
  const [toCurrency, setToCurrency] = useState();
  const [exchangeRate, setExchangeRate] = useState();
  const [amount, setAmount] = useState(1);
  const [amountInFromCurrency, setAmountInFromCurrency] = useState(true);

  if (isApiCalling === false) {
    console.log('Repetitive API calling started');

    setInterval(() => {
      currencyApiCall();
    }, API_CALL_TIMESTAMP);

    isApiCalling = true;
  }

  if (amountInFromCurrency) {
    fromAmount = amount;
    toAmount = amount * exchangeRate;
  } else {
    toAmount = amount;
    fromAmount = amount / exchangeRate;
  }

  function setApiData(data) {
    const toCurrencies = [...Object.keys(data.rates)];
    const firstCurrency = toCurrencies[0];

    setCurrencyOptions(toCurrencies);
    setFromCurrency(data.base);
    setToCurrency(toCurrencies[1]);
    setExchangeRate(data.rates[firstCurrency]);
  }

  function currencyApiCall() {
    fetch(`${URL}/${fromCurrency}`)
      .then((res) => res.json())
      .then((data) => {
        const baseName = data.base;
        const currencies = data.rates;

        if (localStoredData.has(baseName) === false) {
          localStoredData.set(baseName, currencies);
        }

        console.log('Data has been stored locally');
        setApiData(data);
      });
  }

  useEffect(() => {
    if (localStoredData.has(fromCurrency)) {
      setExchangeRate(localStoredData.get(fromCurrency)[toCurrency]);

      console.log(
        'Data has been taken from local storage instead of API calling'
      );

      return;
    }

    currencyApiCall();
  }, [fromCurrency, toCurrency]);

  function handleFromAmountChange(e) {
    setAmount(e.target.value);
    setAmountInFromCurrency(true);
  }

  function handleToAmountChange(e) {
    setAmount(e.target.value);
    setAmountInFromCurrency(false);
  }
  return (
    <>
      <div className="converter-container">
        <div className="title">
          <h1>Convert</h1>
          <hr />
        </div>
        <div className="rows">
          <CurrencyRow
            currencyOptions={currencyOptions}
            selectedCurrency={fromCurrency}
            onChangeCurrency={(e) => setFromCurrency(e.target.value)}
            onChangeAmount={handleFromAmountChange}
            amount={fromAmount}
          />
          <div className="equals">
            <img src={CurrencyArrow} alt="arrows" />
          </div>
          <CurrencyRow
            currencyOptions={currencyOptions}
            selectedCurrency={toCurrency}
            onChangeCurrency={(e) => setToCurrency(e.target.value)}
            onChangeAmount={handleToAmountChange}
            amount={toAmount}
          />
        </div>
      </div>
    </>
  );
}

export default Converter;
