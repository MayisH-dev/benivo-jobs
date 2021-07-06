import { Card, Col, Row } from 'antd'
import { InfoCircleOutlined, TagFilled, TagOutlined } from '@ant-design/icons'

const JobCards = ({ jobs, onRemoveBookmark, onAddBookmark }) => {
  if (jobs && jobs.length > 0)
    return (
      <div>
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
                        <TagFilled key='remove-bookmark' />
                      ) : (
                        <TagOutlined key='add-bookmark' />
                      ),
                      <InfoCircleOutlined key='details' />,
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
