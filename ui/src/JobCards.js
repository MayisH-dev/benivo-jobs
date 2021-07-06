import { Card, Col, Row } from 'antd'
import { InfoCircleOutlined, TagFilled, TagOutlined } from '@ant-design/icons'
import { useState } from 'react'
import JobModal from './JobModal'

const JobCards = ({ jobs, onRemoveBookmark, onAddBookmark }) => {
  const [{ id: modalId }, setModalDisplay] = useState({ id: null })

  const toggleModal = (id) => {
    if (modalId === null) setModalDisplay(id)
    else setModalDisplay({ id: null })
  }

  if (jobs.length > 0)
    return (
      <div>
        <JobModal
          toggleOff={toggleModal}
          visible={modalId !== null}
          id={modalId}
        />
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
                        onClick={() => toggleModal(id)}
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
  else return <div>Nothin to display</div>
}

export default JobCards
