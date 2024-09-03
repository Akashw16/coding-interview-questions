import React from 'react';
import '../styles/QuestionsList.css';
import QuestionAndCodeBlock from './QuestionAndCodeBlock';

const QuestionsList = ({ questionsData = [] }) => {
  // Check if questionsData is an array and has elements
  if (!Array.isArray(questionsData) || questionsData.length === 0) {
    return <p>No questions available or an issue occurred while fetching data.</p>;
  }

  return (
    <div className="questions-list">
      {questionsData.map((q, index) => (
        <div key={q.id} className="question-item">
          <h2 className="question-title">{q.questionText}</h2>
          <QuestionAndCodeBlock questionId={q.id} code={q.codeSnippet} />
        </div>
      ))}
    </div>
  );
};

export default QuestionsList;
