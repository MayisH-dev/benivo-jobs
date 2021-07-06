import { Modal } from 'antd'

const JobModal = ({job, closeModal }) => {

  const { title, description, isBookmarked, companyTitle, location, employmentTypeTitle } = job

  return (<Modal
    onCancel={closeModal}
    onOk={closeModal}
    visible
    title={title}
  >
    <h3>Employment Type: {employmentTypeTitle}</h3>
    <h3>Location: {location}</h3>
    <h3>Company: {companyTitle}</h3>
    <p>Description: {description}</p>
  </Modal>
  );
}

export default JobModal
