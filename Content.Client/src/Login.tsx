import React, { useState } from 'react';

interface LoginProps {
  onSubmitName: (name: string) => void;
}

const Login: React.FC<LoginProps> = ({ onSubmitName }) => {
  const [name, setName] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (name.trim() !== '') {
      onSubmitName(name.trim());
    }
  };

  return (
    <div className='login-container' style={{ padding: '2rem', textAlign: 'center' }}>
      <h1>Enter Your Name</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          placeholder="Your name"
          style={{ padding: '0.5rem', fontSize: '1rem' }}
        />
        <button type="submit" style={{ padding: '0.5rem 1rem', marginLeft: '0.5rem' }}>
          Submit
        </button>
      </form>
    </div>
  );
};

export default Login;