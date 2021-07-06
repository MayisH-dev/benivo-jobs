import { Card, Col, Row } from 'antd'
import { InfoCircleOutlined, TagFilled, TagOutlined } from '@ant-design/icons'
import { useState } from 'react'
import JobModal from './JobModal'
import api from './Api'

const JobCards = ({ jobs, onRemoveBookmark, onAddBookmark }) => {
  const [job, setJob] = useState(null);

  const closeJobModal = () => {
    setJob(null);
  };

  const fetchJob = async id => {
    const response = await api.get(`/jobs/${id}`);
    setJob(response.data);
  };


  if (jobs.length > 0) {
    return (
      <div>

        {job ?
          <JobModal
            closeModal={closeJobModal}
            job={job}
        />
        : null}



        <div className='site-card-wrapper'>
          <Row gutter={16}>
            {jobs.map(
              ({ id, isBookmarked, location, title, employmentTypeTitle }) => (
                <Col key={id} span={8}>
                  <Card
                    title={title}
                    bordered={true}
                    actions={[
                      isBookmarked ? (
                        <TagFilled
                          onClick={() => onRemoveBookmark(id)}
                          key='remove-bookmark'
                        />
                      ) : (
                        <TagOutlined
                          onClick={() => onAddBookmark(id)}
                          key='add-bookmark'
                        />
                      ),
                      <InfoCircleOutlined
                        onClick={() => fetchJob(id)}
                        key='details'
                      />,
                    ]}
                  >
                    <strong>Type:</strong> {employmentTypeTitle}{' '}
                    <strong>Location:</strong> {location}
                  </Card>
                </Col>
              )
            )}
          </Row>
        </div>
      </div>
    )
  }

  else return <div>Nothing to display</div>
}

export default JobCards
